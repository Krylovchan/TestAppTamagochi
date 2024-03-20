class Pet
{
    private const int MaxHealth = 10;
    private const int MaxHunger = 10;
    private const int MaxTiredness = 10;
    private const int MaxHappiness = 10;

    private string _name;
    private int _health;
    private int _hunger;
    private int _tiredness;
    private int _happiness;
    private bool _disease;
    private int _hungerFlag;
    private int _happinessFlag;
    private int _points = 0;

    public string Name { get { return _name; } }
    public int Health { get { return _health; } }
    public int Hunger { get { return _hunger; } }
    public int Tiredness { get { return _tiredness; } }
    public int Happiness { get { return _happiness; } }
    public bool Disease { get { return _disease; } }
    public int Points { get { return _points; } }

    public Pet(string name)
    {
        _name = name;
        ResetAttributes();
    }

    public void ResetAttributes()
    {
        _health = MaxHealth;
        _hunger = 0;
        _tiredness = 0;
        _happiness = MaxHappiness;
        _disease = false;
        _hungerFlag = 0;
        _happinessFlag = 0;
        _points = 0;
    }

    public void Feed()
    {
        if (IsHungerInNormalRange())
        {
            DecreaseHunger();
        }
        else if (IsHealthInNormalRange())
        {
            DecreaseHealth();
        }

        _hungerFlag = 0;
    }

    public void Play()
    {
        if (IsTirednessInNormalRange())
        {
            IncreaseTiredness();
        }
        else if (IsHealthInNormalRange())
        {
            DecreaseHealth();
        }

        IncreaseHunger();
        IncreaseHappiness();

        _happinessFlag = 0;
    }

    public void Sleep()
    {
        if (IsHealthInNormalRange())
        {
            IncreaseHealth();
        }

        IncreaseHunger();

        _tiredness = 0;
    }

    public void Heal()
    {
        _disease = false;

        if (IsHealthInNormalRange())
        {
            IncreaseHealth();
            IncreaseHunger();
            IncreaseTiredness();
        }
        IncreaseHappiness();
    }

    public void Living()
    {
        _happinessFlag++;
        _hungerFlag++;

        if (IsHungerFlagTriggered())
        {
            IncreaseHunger();
        }

        if (IsHappinessFlagTriggered())
        {
            DecreaseHappiness();
        }

        GettingSick();
        PointsByDay();
    }

    private void GettingSick()
    {
        Random rand = new Random();
        int chanseOfGettingSick;

        if (IsHappinessInNormalRange())
        {
            chanseOfGettingSick = rand.Next(0, 20);
        }
        else
        {
            chanseOfGettingSick = rand.Next(0, 10);
        }

        if (chanseOfGettingSick == 1)
        {
            if (_disease)
            {
                Dead();
            }
            else
            {
                _disease = true;
                DecreaseHappiness();
            }
        }
        else if (_disease)
        {
            DecreaseHealthByIllness();
            DecreaseHappiness();
        }
    }
    public void Dead()
    {
        _health = 0;
    }
    public void PointsByDay()
    {
        _points += _health + (MaxHunger - _hunger) + (MaxTiredness - _tiredness) + _happiness;
    }

    private bool IsHealthInNormalRange()
    {
        if (_health >= MaxHealth)
        {
            _health = 10;
        }
        else if (_health <0)
        {
            _health = 0;
        }
        return _health <= MaxHealth && _health > -1;
    }

    private bool IsHungerInNormalRange()
    {
        if (_hunger > MaxHunger)
        {
            DecreaseHealth();
            _hunger = 10;
        }
        else if (_hunger < 0)
        { 
            _hunger = 0;
        }
        return _hunger <= MaxHunger && _hunger > -1;
    }

    private bool IsTirednessInNormalRange()
    {
        if (_tiredness >= MaxTiredness)
        {
            DecreaseHealth();
            _tiredness = 10;
        }
        else if (_tiredness < 0)
        {
            _tiredness = 0;
        }
        return _tiredness <= MaxTiredness && _tiredness > -1;
    }
    private bool IsHappinessInNormalRange()
    {
        if (_happiness >= MaxHappiness)
        {
            _happiness = 10;
        }
        else if (_tiredness < 0)
        {
            _happiness = 0;
        }
        return _happiness <= MaxHappiness && _happiness > -1;
    }

    private bool IsHungerFlagTriggered()
    {
        return _hungerFlag > 3;
    }

    private bool IsHappinessFlagTriggered()
    {
        return _happinessFlag > 3;
    }

    public void IncreaseHealth()
    {
        if (_health < MaxHealth)
        {
            _health++;
        }
    }

    public void DecreaseHealth()
    {
        if (_health > 0)
        {
            _health--;
        }
    }
    
    public void DecreaseHealthByIllness()
    {
        if (_health > 0)
        {
            _health-=3;
        }
    }

    public void IncreaseHunger()
    {
        if (_hunger < MaxHunger)
        {
            _hunger++;
        }
    }

    public void DecreaseHunger()
    {
        if (_hunger > 0)
        {
            _hunger--;
        }
    }

    public void IncreaseTiredness()
    {
        if (_tiredness < MaxTiredness)
        {
            _tiredness += 2;
        }
    }

    public void DecreaseTiredness()
    {
        if (_tiredness > 0)
        {
            _tiredness--;
        }
    }

    public void IncreaseHappiness()
    {
        if (_happiness < MaxHappiness)
        {
            _happiness++;
        }
    }

    public void DecreaseHappiness()
    {
        if (_happiness > 0)
        {
            _happiness--;
        }
    }
}