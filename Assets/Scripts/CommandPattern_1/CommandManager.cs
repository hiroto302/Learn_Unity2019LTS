using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CommandManager : MonoSingletone<CommandManager>
{
    // ICommandで実装された入力処理が発生した時、その入力情報保存(格納)するためのList
    private List<ICommand> _commandBuffer = new List<ICommand>();

    // command 情報 を commandBuffer に追加する処理
    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }

    // Create a play routine triggered by a play method that's going to play back all the commands
    // 1 second delay
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }
    // 再生
    IEnumerator PlayRoutine()
    {
        Debug.Log("Playing...");
        foreach(var command in _commandBuffer)
        {
            command.Execute();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Finished!!");
    }

    // Create a rewind routine triggered by a rewind method that's going to play in reverse
    // 1 second delay
    // 巻き戻し再生
    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }
    IEnumerator RewindRoutine()
    {
        foreach(var command in Enumerable.Reverse(_commandBuffer))
        {
            command.Undo();
            yield return new WaitForSeconds(1);
        }
    }

    // Done = Finished with Changing colors. Turn them all white
    public void Done()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach(var cube in cubes)
        {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    // Reset = Clear the command buffer
    public void Reset()
    {
        _commandBuffer.Clear();
    }
}
