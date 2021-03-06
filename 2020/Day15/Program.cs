﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt").Select(s => s.Split(",")).ToArray();

// Part One
Console.WriteLine(GetNthPosition(Array.ConvertAll(lines[0], long.Parse), 2020));

// Part Two
Console.WriteLine(GetNthPosition(Array.ConvertAll(lines[0], long.Parse), 30000000L));

static long GetNthPosition(long[] numbers, long pos)
{
    Dictionary<long, long> lastTurns = new();
    for(var i = 1; i <= numbers.Length; i++)
    {
        lastTurns[numbers[i - 1]] = i;
    }

    long turnCounter = numbers.Length;
    long number = numbers.Last();

    while(turnCounter < pos)
    {
        long prevNumber = number;

        number = lastTurns.ContainsKey(number) ? turnCounter - lastTurns[number] : 0;
        lastTurns[prevNumber] = turnCounter;

        turnCounter++;
    }

    return number;
}