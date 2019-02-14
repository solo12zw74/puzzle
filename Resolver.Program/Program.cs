using Resolver.Contracts;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Resolver.Program
{
    class Program
    {
        private static readonly Container _container;

        Dictionary<int, IResolver> _resolveres = new Dictionary<int, IResolver>();

        static void Main(string[] args)
        {
            bool @continue = true;
            var ui = _container.GetInstance<UserInterface>();

            while (@continue)
            {
                @continue = ui.RequestUserAction();
            }
        }

        static Program()
        {
            _container = new Container();

            _container.Collection.Register<IResolver>(
                typeof(AStar.AStarResolver),
                typeof(AStar.FSharp.AStarResolver));

            _container.Register<UserInterface>();

            _container.Verify();
        }
    }
}
