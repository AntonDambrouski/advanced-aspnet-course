using DesignPatterns.ProxyProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ProxySolution
{
    internal class ProxySolutionDemo : IDemo
    {
        public void Execute()
        {
            List<User> users = new List<User>();
            users.Add( new User(18));
            users.Add( new User(45));
            users.Add( new User(82));
            foreach (User user in users) 
            {
               new ProxyCarService(user).GetCar();
            }
        }
        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }

    }


    public interface ICarService
    {
        public void GetCar();
    }

    public class CarService : ICarService
    {

        public void GetCar()
        {
           
        }
    }



    public class ProxyCarService : ICarService
    {

        private CarService? _carService;

        private readonly User _user;



        public ProxyCarService(User user)
        {
            _user = user;
        }


        public void GetCar()
        {

            if (_user.Age < 25 || _user.Age > 80)
            {
                Console.WriteLine($"Your age:{_user.Age} does not allow you to take a car");

            }
            else
            {
                if (_carService == null)
                {
                    _carService = new CarService();
                }
                _carService.GetCar();
                Console.WriteLine($"Car is taken by user age {_user.Age}");
            }
        }
    }




    public class User
    {
        public int Age { get; set; }

        public User(int age)
        {
            Age = age;
        }
    }
}





