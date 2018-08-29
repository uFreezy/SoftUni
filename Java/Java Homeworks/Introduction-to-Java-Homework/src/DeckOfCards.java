import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.pdf.ColumnText;
import com.itextpdf.text.pdf.PdfWriter;
import com.itextpdf.text.Rectangle;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.pdf.PdfContentByte;
import com.itextpdf.text.Font;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.BaseColor;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class DeckOfCards {
    public static void main(String[] args) throws IOException {
    	Document doc = new Document();
    	try {
			PdfWriter writer = PdfWriter.getInstance(doc, new FileOutputStream("Deck-of-Cards.pdf"));
			doc.open();
			PdfContentByte cb = writer.getDirectContent(); //?

			int left = 280;
			int right = 380;
			int top = 830;
			int bot = 680;
			int count = 0;
			String[] paints = {"♠","♣","♦","♥"};
			String[] cards = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
			BaseFont base = BaseFont.createFont("/home/xubuntu/workspace/Introduction-to-Java-Homework/fonts/Arial.ttf",
					BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			Font unicodeBlack = new Font(base, 25, Font.BOLD, new BaseColor(0,0,0));
			Font unicodeRed = new Font(base, 25, Font.BOLD, new BaseColor(255,0,0));
			
			for(int k = 0; k < 4;k++) {
				for(int i = 0; i < 12; i++) {
					if(count == 4) {
						count = 0;
						top = 830;
						bot = 680;
						doc.newPage();
						count++;
					}
					else {
						count++;
					}
					//draw rectangle
					Rectangle asd3 = new Rectangle(50,50);
					asd3.setBorder(Rectangle.BOX);
					asd3.setBorderWidth(2);
					asd3.setLeft(left);
					asd3.setRight(right);
					asd3.setTop(top);
					asd3.setBottom(bot);
					doc.add(asd3);
					top -= 170;
					bot -= 170;
					//draw text
					String text = cards[i] + paints[k];
					if(k >= 2) {
						ColumnText.showTextAligned(cb, Element.ALIGN_CENTER, new Phrase(text,unicodeRed), 
								(asd3.getLeft() + asd3.getRight()) / 2, (asd3.getBottom() + 75),0);
					}
					else {
						ColumnText.showTextAligned(cb, Element.ALIGN_CENTER, new Phrase(text,unicodeBlack), 
								(asd3.getLeft() + asd3.getRight()) / 2, (asd3.getBottom() + 75),0);
					}
				}
			}
			doc.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (DocumentException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

    	
    }
}