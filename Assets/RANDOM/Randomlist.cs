using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deedle;

public class Randomlist : MonoBehaviour


{

    public GameObject[] myObjects; 
    public GameObject[] birthplace;


    public bool isCanCreat

    {
        get
        {
            return time <= 0f && trialIndex < nTrials;

        }
    }
    private float time;
    private int trialIndex;
    private int nTrials;
    private Frame<int,string> df;






    void Start()
    {
        time = 5f;
        trialIndex = -1;



        //string basePath = 
        string trialFilePath = "Assets/CSV/space-trials.csv";

        // TODO:
        // In the final product, result file name should include
        // participant id and datetime. No hurry.
        //string resultFilePath =
            //Path.Combine(basePath, @"data\res-space.csv");

        df = Frame.ReadCsv(trialFilePath);

        //nTrials = df.Rows.KeyCount;
        nTrials = 5;



        print(">> original df:");
        df.Print();

        // new columns to be added to dfOut
        // example: accuracy
        List<int> listAccuracy = new List<int>();

        
        
    }
    void creatPrefab()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        int tmp_index_birthplace = Random.Range(0, birthplace.Length);
        
        Instantiate(myObjects[randomIndex], birthplace[tmp_index_birthplace].transform.position, Quaternion.identity);

        time = 5f;


    


    }
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        if (isCanCreat)
        {
            trialIndex++;
            print(df.Rows[trialIndex]);

            // accessing the cells in a row is easy:

            print( $"\tObject Index: {df.Rows[trialIndex]["object_index"]}" );
            print( $"\tLoc: {df.Rows[trialIndex]["loc_x"]} {df.Rows[trialIndex]["loc_y"]} {df.Rows[trialIndex]["loc_z"]}");

            creatPrefab();

        }

    }
}



