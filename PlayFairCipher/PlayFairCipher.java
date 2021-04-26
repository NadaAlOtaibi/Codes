package playfaircipher;


public class Cipher 
{
	

	public String encryptDecrypt(String key, String inputText, boolean Encrypted)//Deciding if the input needs to be decrypted or encrypted
	{
		if(Encrypted==false)
		{
			return encryptText(key, inputText);
			
		}
		
		return decryptText(key, inputText); 
		
		
	}
	///////////////////////////////////////////////////////
	///////////////////////////////////////////////////////
	private String encryptText(String key, String inputText)//if the inputtext was not encrypted
	{
		char[][] matr = prepareInputText(inputText);
		Table playfairB = new Table(key);
		String encryptedText = "";
		
		
		for(int i = 0; i < matr.length; i++)
		{
			encryptedText = encryptedText + playfairB.encryptDi(matr[i]);
		}
		
		return encryptedText;
	}
	//////////////////////////////////////////////////////
	//////////////////////////////////////////////////////
	private String decryptText(String key, String inputText)//if the inputtext was already encrypted
	{
		char[][] matr = prepareInputText(inputText);
		Table playfairB = new Table(key);
		String decryptedText = "";
		
		for(int i = 0; i < matr.length; i++)
		{ 
			decryptedText = decryptedText + playfairB.decryptDi(matr[i]);
		}
		
		return decryptedText;
	}
	////////////////////////////////////////////////////
	////////////////////////////////////////////////////
	private char[][] prepareInputText(String inputText)//preparing inputtext to be encrypted/decrypted
	{
		
		inputText = inputText.toUpperCase();
		inputText = inputText.replaceAll("\\s", "");//remove all whitespaces
		String inputTextN = "";
		int b = 0;
		int c = 0;
		for(int i=0; i<inputText.length(); i++) {//prearing the input text if there were two similar letters in same pair 
			if(i==0) {
				if(inputText.charAt(b) == 'J') {
				inputTextN = inputTextN + 'I';
				}
				else {
				inputTextN = inputTextN + inputText.charAt(b);
				}
				b++;
			}
			else if(i%2!=0 && inputText.charAt(b)==inputText.charAt(c) && inputTextN.length()%2!=0) {
				if(inputText.charAt(b) == 'J') {
				inputTextN = inputTextN + 'X' + 'I';
				}
				else {
				inputTextN = inputTextN + 'X' + inputText.charAt(b);
				}
				b++;
				c++;
			}
			else{
				if(inputText.charAt(b) == 'J') {
				inputTextN = inputTextN + 'I';
				}
				else {
				inputTextN = inputTextN + inputText.charAt(b);
				}
				b++;
				c++;
			}
		}
		/////////////////////////////////////
		if(inputTextN.length()%2 != 0)//putting all inputtext characters in matrix
		{
			inputTextN = inputTextN + 'X';
		}
		
		char[][] matr = new char[inputTextN.length()/2][2];
		int k = 0;
		for(int i=0; i<inputTextN.length()/2; i++)
		{
			for(int j=0; j<2; j++)
			{
				matr[i][j] = inputTextN.charAt(k);
				k++;
			}
		}
		return matr;
	}



}
