import java.util.Date;

public class Main {

	public static void main(String[] args) {

		HumanJob h = new HumanJob("Bob", new Date(2023,2,12), 10, HumanJob.Job.CHILD);
		
		LambdaOper lambda =(name)->{
			if(name.length()>3) {
				System.out.println("name longer than 3");
			}
			else
			{
				System.out.println("name shortar than 3");
			}
		};
		
		lambda.lambda(h.getNume());
		
		HumanColection hashmap = new HumanColection();
		hashmap.populate();
		hashmap.printAll();
		System.out.println("\n");
		hashmap.add(h);
		hashmap.printAll();
		System.out.println("\n");
		hashmap.delete(h);
		hashmap.printAll();
		
		hashmap.serialize("collection.bin");
		
		hashmap.run();
		
		Thread test = new Thread(hashmap);
		test.start();

	}

}
