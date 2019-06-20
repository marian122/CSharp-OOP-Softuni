using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;
        public Player(ICardRepository cardRepository,string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.cardRepository = cardRepository;
        }

        public string Username
        {
            get => this.username;

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }

                this.username = value;
            }
        }
        public int Health
        {
            get => this.health;

            set
            {
                if (health < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                health = value;
            }
        }

        public ICardRepository CardRepository { get; }

        public bool IsDead { get; }

        public abstract void TakeDamage(int damagePoints);
    }
}
