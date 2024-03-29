﻿namespace LoggerLibrary.Layouts.Factory
{
    using LoggerLibrary.Contracts;
    using LoggerLibrary.Layouts.Factory.Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "simplelayout":
                    return new SimpleLayout();

                case "xmllayout":
                    return new XmlLayout();

                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }


    }
}
