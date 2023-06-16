﻿using Logic.Grid;

namespace Logic.Serializer.Serialize;

public class SamuraiSerialize : ISerialize
{
    public string[] Serialize(Board sudoku)
    {
        string testData = "111222333111222333111222333444555666444555666444555666777888999777888999777888999111222333111222333111222333444555666444555666444555666777888999777888999777888999111222333111222333111222333444555666444555666444555666777888999777888999777888999111222333111222333111222333444555666444555666444555666777888999777888999777888999111222333111222333111222333444555666444555666444555666777888999777888999777888999";
        return testData.Select(c => c.ToString()).ToArray();
    }
}

