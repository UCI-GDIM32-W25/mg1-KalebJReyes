using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

    private void Update()
    {
        // Moves player left/right
        if (Input.GetKey("a"))
        {
            _playerTransform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        else if (Input.GetKey("d")) 
        {
            _playerTransform.Translate(Vector3.right * Time.deltaTime * _speed);
        }
        // Moves player up/down
        if (Input.GetKey("w"))
        {
            _playerTransform.Translate(Vector3.up * Time.deltaTime * _speed);
        }
        else if (Input.GetKey("s"))
        {
            _playerTransform.Translate(Vector3.down * Time.deltaTime * _speed);
        }

        if (Input.GetKeyDown("space")) 
        {
            PlantSeed();
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }
    }

    public void PlantSeed ()
    {
        if (_numSeedsLeft > 0) 
        { 
            _numSeedsLeft--;
            _numSeedsPlanted++;

            Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity);
        }
    }
}
