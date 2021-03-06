﻿using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер приёма пищи
    /// </summary>
    public class EatingController : ControllerBase
    {
        private User User;
        public List<Food> Foods { get; }
        public Eating Eating { get; } 

        public EatingController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(User);
        }

        private List<Eating> GetAllEating()
        {
            return Load<List<Eating>>(EATINGS_FILE_NAME) ?? new List<Eating>();
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        public void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
