import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class Utils {
    private static List<Vehicle> list;

    public static List<Vehicle> readBinaryCars(String file) {
        List<Vehicle> list1 = new ArrayList<>();
        try(ObjectInputStream ois = new ObjectInputStream(new FileInputStream(file))) {
            while(true) {
                try {
                    list1.add((Car)ois.readObject());
                } catch(Exception e) {
                    break;
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        return list1;
    }

    public static void writeBinaryCars(String file, List<Vehicle> listP) {
        try(ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(file))) {
            for(var car : listP)
                oos.writeObject(car);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static List<Vehicle> readCars(String file) {
        List<Vehicle> list1 = new ArrayList<>();

        try(RandomAccessFile raf = new RandomAccessFile(file, "r")) {
            while(true) {
                try {
                    Car car = new Car();

                    car.setWeight(Float.parseFloat(raf.readLine()));
                    car.setPrice(Double.parseDouble(raf.readLine()));
                    car.setProducer(raf.readLine());

                    list1.add(car);
                } catch(Exception e) {
                    break;
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        return list1;
    }

    public static List<Vehicle> createCars(int n) throws Exception {
        list = new ArrayList<>();
        for(int i = 0; i < n; i++)
            list.add(new Car());
        return list;
    }
}
