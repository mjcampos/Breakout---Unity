using UnityEngine;

public class Lives : MonoBehaviour {
    int _lives = 3;
    bool _playerAlive = true;

    public void ResetLives()
    {
        _lives = 3;
        _playerAlive = true;
    }

    public void RemoveLife()
    {
        _lives--;

        if (_lives < 1)
        {
            _playerAlive = false;
        }
    }

    public bool GetPlayerAlive()
    {
        return _playerAlive;
    }
}
