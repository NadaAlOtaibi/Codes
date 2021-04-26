package playfaircipher;


import java.awt.EventQueue; 
import javax.swing.JFrame;
import javax.swing.JTextField;
import java.awt.Font;
import javax.swing.JLabel;
import javax.swing.JCheckBox;
import javax.swing.JButton;
import javax.swing.JTextArea;
import javax.swing.JOptionPane;
import javax.swing.UIManager;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.Color;
import javax.swing.SwingConstants;
import java.awt.Window.Type;
import javax.swing.text.PlainDocument; 
import javax.swing.text.AttributeSet;
import javax.swing.text.BadLocationException;

@SuppressWarnings("serial")
class JTextFieldLimit extends PlainDocument 
{
  private int limit;

  JTextFieldLimit(int limit) 
  {
   super();
   this.limit = limit;
   }

  public void insertString( int offset, String  str, AttributeSet attr ) throws BadLocationException 
  {
    if (str == null) return;

    if ((getLength() + str.length()) <= limit) {
      super.insertString(offset, str, attr);
    } 
  }
}
////////////////////////////
////////////////////////////
///////////////////////////
public class PlayfairGUI {

	private JFrame playcipherFrm;
	private JTextField inputText;
	private JTextArea outputText;
	private JTextField key;
	private JLabel lblText;

	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
					PlayfairGUI window = new PlayfairGUI();
					window.playcipherFrm.setVisible(true);
					window.playcipherFrm.setTitle("Playfair Cipher");
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	public PlayfairGUI() {
		initialize();
	}

	
	private void initialize() {
		playcipherFrm = new JFrame();
		playcipherFrm.setBackground(new Color(255, 255, 255));
		playcipherFrm.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		playcipherFrm.setType(Type.POPUP);
		playcipherFrm.setFont(new Font("Yu Gothic UI Semibold", Font.BOLD, 18));
		playcipherFrm.setTitle("PlayCipher ");
		playcipherFrm.getContentPane().setFont(new Font("Yu Gothic", Font.BOLD, 10));
		playcipherFrm.getContentPane().setBackground(new Color(255, 204, 204));
		playcipherFrm.setBounds(300, 300, 450, 406);
		playcipherFrm.getContentPane().setLayout(null);
		
		key = new JTextField();
		key.setFont(new Font("Yu Gothic UI Semibold", Font.PLAIN, 20));
		key.setBounds(49, 105, 355, 36);
		playcipherFrm.getContentPane().add(key);
		key.setColumns(1);
		key.setDocument(new JTextFieldLimit(15));
		key.setHorizontalAlignment(JTextField.CENTER);
		
		JLabel lblKey = new JLabel("Key:");
		lblKey.setForeground(new Color(51, 0, 51));
		lblKey.setFont(new Font("Yu Gothic UI Semibold", Font.PLAIN, 17));
		lblKey.setBounds(10, 114, 39, 27);
		playcipherFrm.getContentPane().add(lblKey);
		
		inputText = new JTextField();
		inputText.setHorizontalAlignment(SwingConstants.CENTER);
		inputText.setFont(new Font("Yu Gothic UI Semibold", Font.BOLD, 20));
		inputText.setBounds(49, 56, 355, 36);
		playcipherFrm.getContentPane().add(inputText);
		inputText.setColumns(10);
		
		lblText = new JLabel("Text:");
		lblText.setHorizontalAlignment(SwingConstants.CENTER);
		lblText.setFont(new Font("Yu Gothic UI Semibold", Font.BOLD, 16));
		lblText.setBackground(Color.PINK);
		lblText.setBounds(10, 61, 39, 22);
		playcipherFrm.getContentPane().add(lblText);
		
		final JCheckBox chckbxTextIsEncrypted = new JCheckBox("Encrypted Text");
		chckbxTextIsEncrypted.setHorizontalAlignment(SwingConstants.CENTER);
		chckbxTextIsEncrypted.setFont(new Font("Yu Gothic UI Semibold", Font.BOLD, 12));
		chckbxTextIsEncrypted.setBounds(139, 154, 163, 23);
		playcipherFrm.getContentPane().add(chckbxTextIsEncrypted);
		
		JButton btnEncryptDecrypt = new JButton("Encrypt  or  Decrypt");
		btnEncryptDecrypt.setFont(new Font("Yu Gothic UI Semibold", Font.BOLD, 12));
		btnEncryptDecrypt.addMouseListener(new MouseAdapter() 
			{
			@Override
			public void mouseClicked(MouseEvent e)
			{
				if(validate())
				{
					Cipher C = new Cipher();
					outputText.setText(C.encryptDecrypt(key.getText(), inputText.getText(), chckbxTextIsEncrypted.isSelected()));//String, String, boolean
				}
				else
				{
					JOptionPane.showMessageDialog(playcipherFrm, "Please enter English letters only","Error", JOptionPane.ERROR_MESSAGE);
				} 
			}
		});
		btnEncryptDecrypt.setBounds(139, 190, 163, 58);
		playcipherFrm.getContentPane().add(btnEncryptDecrypt);
		
		outputText = new JTextArea();
		outputText.setFont(new Font("Yu Gothic UI Semibold", Font.PLAIN, 26));
		outputText.setEditable(false);
		outputText.setBounds(49, 268, 355, 48);
		playcipherFrm.getContentPane().add(outputText);
		
		JLabel lblResult = new JLabel("Result:");
		lblResult.setHorizontalAlignment(SwingConstants.CENTER);
		lblResult.setForeground(new Color(51, 0, 51));
		lblResult.setFont(new Font("Yu Gothic UI Semibold", Font.PLAIN, 22));
		lblResult.setBounds(10, 230, 81, 27);
		playcipherFrm.getContentPane().add(lblResult);
	}
	
	private boolean validate()
	{
		inputText.setText(inputText.getText().replaceAll("[^a-zA-Z]", ""));
		key.setText(key.getText().replaceAll("[^a-zA-Z]", ""));
		
		if(key.getText().length()>0 && inputText.getText().length()>0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}

