﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase
{
    public class InvalidSongMinutesException : InvalidSongException
    {
        public InvalidSongMinutesException(string message = "Song minutes should be between 0 and 14.")
            : base(message)
        {

        }
    }
}
