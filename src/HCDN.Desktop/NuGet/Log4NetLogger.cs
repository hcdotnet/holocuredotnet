﻿using System;
using System.Threading.Tasks;
using log4net;
using NuGet.Common;

namespace HCDN.Desktop.NuGet;

/// <summary>
///     A NuGet <see cref="ILogger"/> implementation which uses log4net.
/// </summary>
internal sealed class Log4NetLogger : ILogger {
    private readonly ILog logger;

    public Log4NetLogger(ILog logger) {
        this.logger = logger;
    }

    void ILogger.LogDebug(string data) {
        logger.Debug(data);
    }

    void ILogger.LogVerbose(string data) {
        logger.Debug(data);
    }

    void ILogger.LogInformation(string data) {
        logger.Info(data);
    }

    void ILogger.LogMinimal(string data) {
        logger.Info(data);
    }

    void ILogger.LogWarning(string data) {
        logger.Warn(data);
    }

    void ILogger.LogError(string data) {
        logger.Error(data);
    }

    void ILogger.LogInformationSummary(string data) {
        logger.Info(data);
    }

    void ILogger.Log(LogLevel level, string data) {
        switch (level) {
            case LogLevel.Debug:
                logger.Debug(data);
                break;

            case LogLevel.Verbose:
                logger.Debug(data);
                break;

            case LogLevel.Information:
                logger.Info(data);
                break;

            case LogLevel.Minimal:
                logger.Info(data);
                break;

            case LogLevel.Warning:
                logger.Warn(data);
                break;

            case LogLevel.Error:
                logger.Error(data);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(level), level, null);
        }
    }

    Task ILogger.LogAsync(LogLevel level, string data) {
        AsLogger().Log(level, data);
        return Task.CompletedTask;
    }

    void ILogger.Log(ILogMessage message) {
        AsLogger().Log(message.Level, message.Message);
    }

    Task ILogger.LogAsync(ILogMessage message) {
        AsLogger().Log(message);
        return Task.CompletedTask;
    }

    private ILogger AsLogger() {
        return this;
    }
}
