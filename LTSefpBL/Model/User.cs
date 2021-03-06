﻿#region Libraries
using System;
using System.Resources;
#endregion

namespace LTSefpBL.Model
{///Пользователь.
    [Serializable]
    public class User
{
        public int Id { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Тип заработка.
        /// </summary>
        public IncomeType Type { get; set; }
        /// <summary>
        /// Заработок.
        /// </summary>
        public int Earning { get; set; }
        /// <summary>
        /// Cоздать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="type">Тип зароботка.</param>
        /// <param name="earning">Заработок.</param>
        /// 

        public int Age() 
        {   
            if(BirthDate.Year > 1900 && BirthDate.Year <= DateTime.Now.Year)
            {
                return DateTime.Now.Year - BirthDate.Year; 
            }
            else
            {
                throw new ArgumentNullException("This is not your age.");
            }
        }
        /// <summary>
        /// Поздравление с днём рождения
        /// </summary>
        public string Birth
        {
            get
            {
                if (DateTime.Now.Day == BirthDate.Day && DateTime.Now.Month == BirthDate.Month)
                {
                    return "Поздравляем вас с днём рождения:)";
                }
                else
                {
                    return "";
                }
            }
        }

        public User() { }

        public User(string name,
                    DateTime birthDate,
                    IncomeType type,
                    int earning)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (birthDate < DateTime.Parse("01.01.1950") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Невозможная дата рождения.", nameof(birthDate));
            }
            if (earning <= 0)
            {
                throw new ArgumentNullException("Для пользования приложением заработок должен быть больше 0.", nameof(earning));
            }
            #endregion
            Name = name;
            Type = type ?? throw new ArgumentNullException("Income type не может быть null.", nameof(type));
            BirthDate = birthDate;
            Earning = earning;

        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(name));
            }
            Name = name;
        }


        public string Hello(ResourceManager resMan, System.Globalization.CultureInfo culture)
        {
            return $"{resMan.GetString("HelloName", culture)} {Name}! {resMan.GetString("Age", culture) + Age() + Birth}";
        }
    }
}
