using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite[ ] playerIcons; // 0 for x or 1 for o
    public Button[ ] spaces; // space on game grid
    public int[ ] markedSpaces;
    int snowflakes = 0;
    int snowballs = 0;
    // Start is called before the first frame update
    void Start()
    {
        for( int i = 0; i < spaces.Length; i ++ )
        {
            spaces[ i ].interactable = true;
            spaces[ i ].GetComponent<Image>( ).sprite = null;
        }
        for( int i = 0; i < markedSpaces.Length; i ++ )
        {
            markedSpaces[ i ] = -1;
        }    
    }

    void ChangeScene( )
    {
       SceneManager.LoadSceneAsync( "End Page" );
    }
    void RepeatScene( )
    {
       SceneManager.LoadSceneAsync( "Tic-Tac-Toe" );
    }

    // Update is called once per frame
    void Update()
    {
        if( !CheckGameOn())
        {
            int index = 0;
            foreach( Button position in spaces )
            {
                spaces[ index ].interactable = false;
                index ++;
            }
            if( FindWinner( ) )
            {
                Invoke( "ChangeScene", 2 );
            }
            else Invoke( "RepeatScene", 2 );
        }
        if( snowflakes > snowballs && CheckGameOn( ) )
        {
            OpponentMove( );
            snowballs ++;
        }
        
    }

    public void TicTacToeButton( int buttonNumber )
    {
        spaces[ buttonNumber ].image.sprite = playerIcons[ 0 ];
        spaces[ buttonNumber ].interactable = false;
        markedSpaces[ buttonNumber ] = 0;
        snowflakes ++;
    }

    void OpponentMove( )
    {
        int move = RandomMove(); // returns int representing array index of oponent move
        spaces[ move ].image.sprite = playerIcons[ 1 ];
        spaces[ move ].interactable = false;
        markedSpaces[ move ] = 1;
    }


    int RandomMove() // returns int representing array index of opponent move
    {//continue changing this
        int move;
        // make sure this returns a single digit number (0 to 8) 
        while( true )
        {
            move = Random.Range( 0, 9 );
            if( markedSpaces[ move ] == -1 ) return move;
        }
        return -1;
    }
    bool CheckGameOn()
    {                
        bool check = false;
        
        if( (markedSpaces[ 0 ] == 0 && markedSpaces[ 1 ] == 0 && markedSpaces[ 2 ] == 0 ) || // row 1
            (markedSpaces[ 3 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 5 ] == 0 ) || // row 2
            (markedSpaces[ 6 ] == 0 && markedSpaces[ 7 ] == 0 && markedSpaces[ 8 ] == 0 ) || // row 3
            (markedSpaces[ 0 ] == 0 && markedSpaces[ 3 ] == 0 && markedSpaces[ 6 ] == 0 ) || // column 1
            (markedSpaces[ 1 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 7 ] == 0 ) || // column 2
            (markedSpaces[ 2 ] == 0 && markedSpaces[ 5 ] == 0 && markedSpaces[ 8 ] == 0 ) || // column 3
            (markedSpaces[ 0 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 8 ] == 0 ) || // top left diagonal
            (markedSpaces[ 2 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 2 ] == 0 ) )  // top right diagonal
        {
            check = false;
        }
        else if(    (markedSpaces[ 0 ] == 1 && markedSpaces[ 1 ] == 1 && markedSpaces[ 2 ] == 1 ) || // row 1
                    (markedSpaces[ 2 ] == 1 && markedSpaces[ 7 ] == 1 && markedSpaces[ 8 ] == 1 ) || // row 3
                    (markedSpaces[ 0 ] == 1 && markedSpaces[ 1 ] == 1 && markedSpaces[ 2 ] == 1 ) || // column 1
                    (markedSpaces[ 1 ] == 1 && markedSpaces[ 4 ] == 1 && markedSpaces[ 5 ] == 1 ) || // row 2
                    (markedSpaces[ 1 ] == 1 && markedSpaces[ 4 ] == 1 && markedSpaces[ 7 ] == 1 ) || // column 2
                    (markedSpaces[ 2 ] == 1 && markedSpaces[ 5 ] == 1 && markedSpaces[ 8 ] == 1 ) || // column 3
                    (markedSpaces[ 0 ] == 1 && markedSpaces[ 4 ] == 1 && markedSpaces[ 8 ] == 1 ) || // top left diagonal
                    (markedSpaces[ 2 ] == 1 && markedSpaces[ 4 ] == 1 && markedSpaces[ 2 ] == 1 ) )  // top right diagonal
        {
            check = false;
        }
        else check = true;
        
        return check;
    }

    bool CheckTie()
    {
        bool tie = true;
        
        for(int i = 0; i < markedSpaces.Length; i++)
        {
            if(markedSpaces[ i ] != -1)
            {
                tie = false;
            }
        }
        return tie;
    }

    bool FindWinner( )
    {
        bool check = false;
                
        if( (markedSpaces[ 0 ] == 0 && markedSpaces[ 1 ] == 0 && markedSpaces[ 2 ] == 0 ) || // row 1
            (markedSpaces[ 3 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 5 ] == 0 ) || // row 2
            (markedSpaces[ 6 ] == 0 && markedSpaces[ 7 ] == 0 && markedSpaces[ 8 ] == 0 ) || // row 3
            (markedSpaces[ 1 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 7 ] == 0 ) || // column 2
            (markedSpaces[ 2 ] == 0 && markedSpaces[ 5 ] == 0 && markedSpaces[ 8 ] == 0 ) || // column 3
            (markedSpaces[ 0 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 8 ] == 0 ) || // top left diagonal
            (markedSpaces[ 2 ] == 0 && markedSpaces[ 4 ] == 0 && markedSpaces[ 2 ] == 0 ) )  // top right diagonal
        {
            return true; // player won
        }
        else if(    (markedSpaces[ 0 ] == -1 && markedSpaces[ 1 ] == -1 && markedSpaces[ 2 ] == -1 ) || // row 1
                    (markedSpaces[ 1 ] == -1 && markedSpaces[ 4 ] == -1 && markedSpaces[ 5 ] == -1 ) || // row 2
                    (markedSpaces[ 2 ] == -1 && markedSpaces[ 7 ] == -1 && markedSpaces[ 8 ] == -1 ) || // row 3
                    (markedSpaces[ 0 ] == -1 && markedSpaces[ 1 ] == -1 && markedSpaces[ 2 ] == -1 ) || // column 1
                    (markedSpaces[ 1 ] == -1 && markedSpaces[ 4 ] == -1 && markedSpaces[ 7 ] == -1 ) || // column 2
                    (markedSpaces[ 2 ] == -1 && markedSpaces[ 5 ] == -1 && markedSpaces[ 8 ] == -1 ) || // column 3
                    (markedSpaces[ 0 ] == -1 && markedSpaces[ 4 ] == -1 && markedSpaces[ 8 ] == -1 ) || // top left diagonal
                    (markedSpaces[ 2 ] == -1 && markedSpaces[ 4 ] == -1 && markedSpaces[ 2 ] == -1 ) )  // top right diagonal
        {
            return false; // computer won
        }
        else return false; // no winner
    }
}
