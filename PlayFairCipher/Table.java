package playfaircipher;
import java.util.HashMap;
import java.util.ArrayList; 
import java.util.Arrays;
import java.util.List;


 @SuppressWarnings("serial")
class ArrIndex extends HashMap<Character, Integer[]>
{
	
	public ArrIndex(char[][] input)
	{
		for(int i=0; i<input.length; i++)
		{
			for(int j=0; j<input[i].length; j++)
			{
				this.put(new Character(input[i][j]), new Integer[] {i,j});
			}
		}
	}

}
///////////////////////////////////////////
/////// M A I N   C L A S S ///////////////
///////////////////////////////////////////
public class Table 
{
	
	
	private char[] key;
	private char[][] cipherMatrix = new char[5][5];// 5X5 matrix/table
	private List<Character> Letters = new ArrayList<Character>(Arrays.asList('A','B','C','D','E','F','G','H','I','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'));//I = I/J
	private ArrIndex idx;
	
	
	
	public Table (String K)
	{
		key = prepareKey(K.toUpperCase().toCharArray());
		cipherMatrix = prepareTable(key);
		idx = new ArrIndex(cipherMatrix);
	} 
	//////////////////////////////////////////////////////
	//////////////////////////////////////////////////////
	public char[] prepareKey(char[] key)//preparing the key
	{
		List<Character> Key2 = new ArrayList<Character>();
		for(int i = 0; i < key.length; i++)
		{
			if(!Key2.contains(key[i]))
			{
				Key2.add(key[i]);
			}
		}
		if(Key2.contains('J'))// I = I/J 
		{
			int i = Key2.indexOf('J');
			Key2.remove(i);
			Key2.add(i, 'I');
		}
		char [] finalKey = ListToCharArray(Key2);
		return finalKey;
	}	
	////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////
	public char[][] prepareTable(char[] key) //preparing the playfair table/matrix
	{

		char[][] matrix = new char[5][5];
		int k = 0;
		
		for(int i=0; i < key.length; i++)
		{
			Letters.remove(Letters.indexOf(key[i]));
			Letters.add(0, key[i]);
		}
		
		for(int i = 0 ; i < 5; i++)
		{
			for(int j = 0; j < 5 ; j++)
			{
				matrix[i][j] = Letters.get(k);
				k++;
			}	
		}
		return matrix;
	}
	////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////
	public String encryptDi(char[] matr)
	{
		
		//matrix => nX2
		char[] output = new char[2]; 
		Integer[] coordsOfChar0 = idx.get(new Character(matr[0]));
		Integer[] coordsOfChar1 = idx.get(new Character(matr[1]));
		
		int X0 = coordsOfChar0[0].intValue();
		int X1 = coordsOfChar1[0].intValue();
		int Y0 = coordsOfChar0[1].intValue();
		int Y1 = coordsOfChar1[1].intValue();
		
		if(X0 != X1 && Y0 != Y1)//both different => taking the Intersection
		{
			output[0] = this.cipherMatrix[X0][Y1];
			output[1] = this.cipherMatrix[X1][Y0];
		}
		else if(X0 != X1 && Y0 == Y1)//same column => shift down
		{
			output[0] = this.cipherMatrix[getEncryptCoord(X0)][Y0];
			output[1] = this.cipherMatrix[getEncryptCoord(X1)][Y1];
		}
		else if(X0 == X1 && Y0 != Y1)//same row => shift right
		{
			output[0] = this.cipherMatrix[X0][getEncryptCoord(Y0)];
			output[1] = this.cipherMatrix[X1][getEncryptCoord(Y1)];
		}
		String strOutput = ArrayToString(output);
		return strOutput;
	}
	////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////
	public String decryptDi(char[] matr)
	{
		//matrix => nX2
		char[] output = new char[2];
		Integer[] coordsOfChar0 = idx.get(new Character(matr[0]));
		Integer[] coordsOfChar1 = idx.get(new Character(matr[1]));
		
		int X0 = coordsOfChar0[0].intValue();
		int X1 = coordsOfChar1[0].intValue();
		int Y0 = coordsOfChar0[1].intValue();
		int Y1 = coordsOfChar1[1].intValue();
		
		if(X0 != X1 && Y0 != Y1)//both different => taking the Intersection
		{
			output[0] = this.cipherMatrix[X0][Y1];
			output[1] = this.cipherMatrix[X1][Y0];
		}
		else if(X0 != X1 && Y0 == Y1)//same column => shift up
		{
			output[0] = this.cipherMatrix[getDecryptCoord(X0)][Y0];
			output[1] = this.cipherMatrix[getDecryptCoord(X1)][Y1];
		}
		else if(X0 == X1 && Y0 != Y1)//same row => shift left
		{
			output[0] = this.cipherMatrix[X0][getDecryptCoord(Y0)];
			output[1] = this.cipherMatrix[X1][getDecryptCoord(Y1)];
		}
		String strOutput = ArrayToString(output);
		return strOutput;
	}
	//////////////////////////////////////////////////////////////
	//////////////H E L P I N G   M E T H O D S///////////////////
	//////////////////////////////////////////////////////////////
	public static String ArrayToString(char[] input)
	{
		String strarr = "";
		for(int i=0; i<input.length; i++)
		{ 
			strarr = strarr + input[i];
		}
		return strarr;
	}
	///////////////////////////////////////////
	///////////////////////////////////////////
	public static char[] ListToCharArray(List<Character> key2)
	{
		char[] key2arr = new char[key2.size()];
		for(int i = 0; i < key2.size(); i++)
		{
			key2arr[i] = key2.get(i);
		}	
		return key2arr;
	}
	////////////////////////////////////////////////////////
	///////////////////G E T T E R S////////////////////////
	////////////////////////////////////////////////////////
	public char[][] getCipherTable() 
	{
		return cipherMatrix;
	}
	//////////////////////////////
	public char[] getKey() 
	{
		return key;
	}
	/////////////////////////////
	private int getEncryptCoord(int coord) 
	{
		
		if(coord < 4)
		{
			return coord + 1;
		}
		else
		{
			return 0;
		}
	}
	///////////////////////////////////
	private int getDecryptCoord(int coord) 
	{
		
		if(coord > 0)
		{
			return coord - 1;
		}
		else
		{
			return 4;
		}
	}

}


