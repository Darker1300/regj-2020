using UnityEngine;

public class Branch : MonoBehaviour
{
    public Pipe pipePrefab = null;

    public int pipeCount = 4;

    [SerializeField]
    private Pipe[] pipes;

    [SerializeField]
    private bool doBuildPipes = false;

    [SerializeField]
    private bool doClearPipes = false;

    private void Awake()
    {
        BuildPipes();
    }

    public void ClearPipes()
    {
        foreach (Pipe pipe in pipes)
        {
            if (pipe)
                GameObject.Destroy(pipe.gameObject);
        }
        pipes = null;
    }

    public void BuildPipes()
    {
        ClearPipes();

        pipes = new Pipe[pipeCount];
        for (int i = 0; i < pipes.Length; i++)
        {
            Pipe pipe = pipes[i] = Instantiate<Pipe>(pipePrefab);
            pipe.transform.SetParent(transform, false);
            if (i > 0)
            {
                pipe.AlignWith(pipes[i - 1]);
            }
        }
    }

    private void OnValidate()
    {
        if (doBuildPipes)
        {
            doBuildPipes = false;
            BuildPipes();
        }
        if (doClearPipes)
        {
            doClearPipes = false;
            ClearPipes();
        }
    }
}