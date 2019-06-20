﻿namespace LoggerLibrary.LoggerClass.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);

        void Info(string dateTime, string infoMessage);

        void Warning(string dateTime, string errorMessage);

        void Fatal(string dateTime, string infoMessage);

        void Critical(string dateTime, string errorMessage);


    }
}
