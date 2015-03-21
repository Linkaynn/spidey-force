﻿using UnityEngine;
using System.Collections;

public class Chronometer : MonoBehaviour {

    private float time;

    private float miliseconds;
    private int seconds;
    private int minutes;

    private GameController gameController;

    public static Chronometer instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

	// Use this for initialization
	void Start () {
        time = 0f;
        miliseconds = 0;
        seconds = 0;
        minutes = 0;

        gameController = GameController.instance;

	}
	
	// Update is called once per frame
	void Update () {

        if (gameController.nlifes > 0)
        {
            time += Time.deltaTime;

            miliseconds = Mathf.Floor((time - Mathf.Floor(time)) * 100f);

            if (miliseconds >= 90)
            {
                time = 0;
                miliseconds = 0f;
                seconds++;
            }

            if (seconds >= 59)
            {
                seconds = 0;
                minutes++;
            }

            gameObject.guiText.text = "" + minutes + ":" + seconds + ":" + miliseconds;
        }

	}
}
