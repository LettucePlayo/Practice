import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;

public class HumanColection implements Runnable, Serializable  {

	HashMap<Integer, HumanJob> colectie;

	public HumanColection(HashMap<Integer, HumanJob> colectie) {
		super();
		this.colectie = colectie;
	}
	public HumanColection() {
		
		this.colectie = new HashMap<Integer ,HumanJob>();
	}
	
	public void add(HumanJob hum)
	{
		colectie.put(hum.getId(), hum);
	}
	public void delete(HumanJob hum)
	{
		colectie.remove(hum.getId());
	}
	
	public void populate ()
	{
		String fileName = "./src/Text.txt";

        try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = br.readLine()) != null) {
            	String[] parts = line.split(" ");
                String name = parts[0];
                String dateString = parts[1];
                int id = Integer.parseInt(parts[2]);
                Date birthDate;
                SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy.MM.dd");
                try {
                    birthDate = dateFormat.parse(dateString);
                } catch (ParseException e) {
                    e.printStackTrace();
                    continue;
                }

                HumanJob.Job job = HumanJob.Job.valueOf(parts[3]);

                // Create a new HumanJob object and add it to the HashMap
                HumanJob human = new HumanJob(name, birthDate, id, job);
                colectie.put(id, human);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
	}
	
	public void printAll() {
	    for (HumanJob human : colectie.values()) {
	        System.out.println(human.toString());
	    }
	}
	@Override
	public void run() {
		int counter=0;
		for (HumanJob human : colectie.values()) {
	        System.out.println("suntem la pasul intern " + counter);
	        try {
				Thread.sleep(500);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
	        counter++;
		}
		System.out.println("am finalizat threadu");
	}
	
	public void serialize(String fileName) {
	    try (FileOutputStream fos = new FileOutputStream(fileName);
	         ObjectOutputStream oos = new ObjectOutputStream(fos)) {
	        oos.writeObject(this);
	        System.out.println("Serialization completed. Object saved to " + fileName);
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	
	}
}