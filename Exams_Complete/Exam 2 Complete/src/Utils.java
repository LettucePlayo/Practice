import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class Utils {
    private static List<ElectronicDevices> edl;

    public static List<ElectronicDevices> createPhones(int n) throws Exception {
        edl = new ArrayList<>();
        for(int i = 0; i < n; i++)
            edl.add(new Phone());
        return edl;
    }

    public static void writeBinaryPhones(String file, List<ElectronicDevices> listP) {
        try(ObjectOutputStream objectOutputStream = new ObjectOutputStream(new FileOutputStream(file))) {
            for(var phone : listP) {
                objectOutputStream.writeObject(phone);
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static List<ElectronicDevices> readBinaryPhones(String file) {
        List<ElectronicDevices> list = new ArrayList<>();

        try(ObjectInputStream objectInputStream = new ObjectInputStream(new FileInputStream(file))) {
            while (true) {
                try {
                    list.add((ElectronicDevices) objectInputStream.readObject());
                } catch(IOException | ClassNotFoundException e) {
                    break;
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        return list;
    }

    public static List<ElectronicDevices> readPhones(String file) {
        List<ElectronicDevices> list = new ArrayList<>();

        try(RandomAccessFile raf = new RandomAccessFile(file, "r")) {
            while(true) {
                try {
                    Phone phone = new Phone();

                    phone.setWeight(Float.parseFloat(raf.readLine()));
                    phone.setDiagonal(Double.parseDouble(raf.readLine()));
                    phone.setProducer(raf.readLine());

                    list.add(phone);
                } catch (Exception e) {
                    break;
                }
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        return list;
    }
}
