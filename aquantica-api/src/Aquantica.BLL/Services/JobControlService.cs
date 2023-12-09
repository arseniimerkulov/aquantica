using System.Linq.Expressions;
using Aquantica.BLL.Interfaces;
using Aquantica.Contracts.Requests.JobControl;
using Aquantica.Contracts.Responses.JobControl;
using Aquantica.Core.Constants;
using Aquantica.Core.Entities;
using Aquantica.Core.Enums;
using Aquantica.Core.ServiceResult;
using Aquantica.DAL.UnitOfWork;
using Hangfire;
using Hangfire.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BackgroundJob = Aquantica.Core.Entities.BackgroundJob;

namespace Aquantica.BLL.Services;

public class JobControlService : IJobControlService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWeatherForecastService _weatherForecastService;
    private readonly IArduinoControllersService _arduinoControllersService;
    private readonly ILogger<JobControlService> _logger;

    public JobControlService(IUnitOfWork unitOfWork,
        IWeatherForecastService weatherForecastService,
        IArduinoControllersService arduinoControllersService,
        ILogger<JobControlService> logger)
    {
        _unitOfWork = unitOfWork;
        _weatherForecastService = weatherForecastService;
        _arduinoControllersService = arduinoControllersService;
        _logger = logger;
    }

    public async Task<ServiceResult<List<JobResponse>>> GetAllJobsAsync()
    {
        try
        {
            var jobs = await _unitOfWork.BackgroundJobRepository
                .GetAll()
                .Select(x => new JobResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsEnabled = x.IsEnabled,
                    JobRepetitionType = x.JobRepetitionType,
                    JobRepetitionValue = x.JobRepetitionValue,
                    JobMethod = x.JobMethod,
                })
                .ToListAsync();

            return new ServiceResult<List<JobResponse>>(jobs);
        }
        catch (Exception e)
        {
            return new ServiceResult<List<JobResponse>>(e.Message);
        }
    }


    public async Task<ServiceResult<bool>> FireJobAsMethodAsync(int jobId)
    {
        try
        {
            var job = await _unitOfWork.BackgroundJobRepository.GetByIdAsync(jobId);

            if (job == null)
                return new ServiceResult<bool>("Job not found");

            var method = GetJobMethod(job);

            method.Compile().Invoke();

            return new ServiceResult<bool>(true);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e.Message);
        }
    }

    public async Task<ServiceResult<bool>> TriggerJobAsync(int jobId)
    {
        try
        {
            var job = await _unitOfWork.BackgroundJobRepository.GetByIdAsync(jobId);

            if (job == null)
                return new ServiceResult<bool>("Job not found");

            RecurringJob.TriggerJob(job.Name);

            return new ServiceResult<bool>(true);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e.Message);
        }
    }


    public async Task<bool> StartJobAsync(int jobId)
    {
        try
        {
            var job = await _unitOfWork.BackgroundJobRepository.GetByIdAsync(jobId);

            if (job == null)
                return false;

            job.IsEnabled = true;

            _unitOfWork.BackgroundJobRepository.Update(job);

            await _unitOfWork.SaveAsync();

            RecurringJob.AddOrUpdate(job.Name, GetJobMethod(job), job.CronExpression);

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }


    public async Task<bool> StopJobAsync(int jobId)
    {
        try
        {
            var job = await _unitOfWork.BackgroundJobRepository.GetByIdAsync(jobId);

            if (job == null)
                return false;

            job.IsEnabled = false;

            _unitOfWork.BackgroundJobRepository.Update(job);

            await _unitOfWork.SaveAsync();

            RecurringJob.RemoveIfExists(job.Name);

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<ServiceResult<bool>> StartAllJobsAsync()
    {
        try
        {
            var jobs = await _unitOfWork.BackgroundJobRepository
                .GetAll()
                .ToListAsync();

            foreach (var job in jobs)
            {
                RecurringJob.AddOrUpdate(job.Name, GetJobMethod(job), job.CronExpression);

                job.IsEnabled = true;

                _unitOfWork.BackgroundJobRepository.Update(job);
            }

            await _unitOfWork.SaveAsync();

            return new ServiceResult<bool>(true);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e.Message);
        }
    }

    public async Task<ServiceResult<bool>> StopAllJobsAsync()
    {
        try
        {
            using var connection = JobStorage.Current.GetConnection();

            foreach (var recurringJob in connection.GetRecurringJobs())
            {
                RecurringJob.RemoveIfExists(recurringJob.Id);

                var job = await _unitOfWork.BackgroundJobRepository.FirstOrDefaultAsync(x => x.Name == recurringJob.Id);
                if (job != null)
                    job.IsEnabled = false;

                _unitOfWork.BackgroundJobRepository.Update(job);
            }

            await _unitOfWork.SaveAsync();

            return new ServiceResult<bool>(true);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e.Message);
        }
    }

    public async Task<ServiceResult<bool>> CreateJobAsync(CreateJobRequest request)
    {
        try
        {
            var jobCheck = await _unitOfWork.BackgroundJobRepository.ExistAsync(x => x.Name == request.Name);

            if (jobCheck)
                return new ServiceResult<bool>("Job already exist");

            var job = new BackgroundJob
            {
                Name = request.Name,
                IsEnabled = true,
                JobRepetitionType = request.JobRepetitionType,
                JobRepetitionValue = request.JobRepetitionValue,
                JobMethod = request.JobMethod,
                CronExpression = GetCronExpression(request.JobRepetitionType, request.JobRepetitionValue)
            };

            var method = GetJobMethod(job);

            await _unitOfWork.BackgroundJobRepository.AddAsync(job);

            await _unitOfWork.SaveAsync();

            RecurringJob.AddOrUpdate(job.Name, method, job.CronExpression);

            return new ServiceResult<bool>(true);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e.Message);
        }
    }

    public async Task<ServiceResult<bool>> UpdateJobAsync(UpdateJobRequest request)
    {
        try
        {
            var job = await _unitOfWork.BackgroundJobRepository.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (job == null)
                return new ServiceResult<bool>("Job not found");

            job.Name = request.Name;
            job.IsEnabled = request.IsEnabled;
            job.JobRepetitionType = request.JobRepetitionType;
            job.JobRepetitionValue = request.JobRepetitionValue;
            job.JobMethod = request.JobMethod;
            job.CronExpression = GetCronExpression(request.JobRepetitionType, request.JobRepetitionValue);

            var method = GetJobMethod(job);

            _unitOfWork.BackgroundJobRepository.Update(job);

            await _unitOfWork.SaveAsync();

            RecurringJob.AddOrUpdate(job.Name, method, job.CronExpression);

            return new ServiceResult<bool>(true);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e.Message);
        }
    }

    public async Task<ServiceResult<bool>> DeleteJobAsync(int id)
    {
        try
        {
            var job = await _unitOfWork.BackgroundJobRepository.GetByIdAsync(id);

            if (job == null)
                return new ServiceResult<bool>("Job not found");

            RecurringJob.RemoveIfExists(job.Name);

            _unitOfWork.BackgroundJobRepository.Delete(job);

            await _unitOfWork.SaveAsync();

            return new ServiceResult<bool>(true);
        }
        catch (Exception e)
        {
            return new ServiceResult<bool>(e.Message);
        }
    }
    

    private Expression<Action> GetJobMethod(BackgroundJob job)
    {
        return job.JobMethod switch
        {
            JobMethodEnum.GetWeatherForecast => () => _weatherForecastService.GetWeatherForecastsFromApi(job),
            JobMethodEnum.StartIrrigation => () => _arduinoControllersService.StartIrrigationIfNeeded(job),
            JobMethodEnum.StopIrrigation => () => _arduinoControllersService.StopIrrigation(job),
            _ => throw new ArgumentOutOfRangeException(nameof(job), job.JobMethod, "Invalid job method")
        };
    }

    private string GetCronExpression(JobRepetitionType repetitionType, int value)
    {
        return repetitionType switch
        {
            JobRepetitionType.Seconds => $"*/{value} * * * * *",
            JobRepetitionType.Minutes => $"* */{value} * * * *",
            JobRepetitionType.Hours => $"* * */{value} * * *",
            JobRepetitionType.Days => $"* * * */{value} * *",
            JobRepetitionType.Weeks => $"* * * * */{value} *",
            JobRepetitionType.Months => $"* * * * * */{value}",
            _ => throw new ArgumentOutOfRangeException(nameof(repetitionType), repetitionType,
                "Invalid repetition type")
        };
    }
}