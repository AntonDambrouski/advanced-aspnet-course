using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ProxyProblem
{
    internal class ProxyProblemDemo : IDemo
    {
        public void Execute()
        {
            User youngUser = new User(18);
            User middleUser = new User(45);
            User agedUser = new User(82);
            CarService carServiceYoung = new CarService(youngUser);
            CarService carServiceMiddle = new CarService(middleUser);
            CarService carServiceAged = new CarService(agedUser);
            carServiceYoung.GetCar();
            carServiceMiddle.GetCar();
            carServiceAged.GetCar();


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
        private readonly User _user;


        public CarService(User user)
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
