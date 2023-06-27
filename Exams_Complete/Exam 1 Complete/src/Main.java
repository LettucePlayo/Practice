import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {

        // read text test
        System.out.println("\nTest 1 read text test:");
        List<Vehicle> list = Utils.readCars("carsList.txt");
        for(var car : list)
            System.out.println(car.toString());

        // write and read binary test
        System.out.println("\nTest 2 write and read binary test:");
        Utils.writeBinaryCars("carsList.dat", list);
        List<Vehicle> list2 = Utils.readBinaryCars("carsList.dat");
        for(var car : list2)
            System.out.println(car.toString());

        // runnable test
        System.out.println("\nTest 3 average weight test:");
        VectorThread vectorThread = new VectorThread("carsList.dat");
        Thread r = new Thread(vectorThread);
        r.start();
        try {
            r.join();
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        System.out.println("Average weight: " + vectorThread.getAvgWeight());

        // TCPServer test
        System.out.println("\nTest 4 TCPServer:");
        final int port = 50001;
        try {
            new Thread(() -> {
                TCPServer server = null;
                try {
                    server = new TCPServer(port);
                    server.setF("carsList.dat");
                    server.startTCPServer();
                } catch (Exception e) {
                    throw new RuntimeException(e);
                }
            }).start();
            TCPClient client = new TCPClient(port);
            client.startTCPClient();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }

         // UDPServer test
         System.out.println("\nTest 5 UDPServer:");
         try(UDPClientSocket client = new UDPClientSocket()) {
             final int portUDP = 60001;
             startUDPThread(portUDP);
             System.out.println(client.sendAndReceiveMsg("W?", portUDP));
             startUDPThread(portUDP);
             System.out.println(client.sendAndReceiveMsg("TEST", portUDP));
             startUDPThread(portUDP);
             System.out.println(client.sendAndReceiveMsg("BYE", portUDP));
         } catch (IOException e) {
             throw new RuntimeException(e);
         }
    }

    public static void startUDPThread(int port) {
        new Thread(() -> {
            try (UDPServerSocket server = new UDPServerSocket(port)) {
                server.processRequest();
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }).start();
        try {
            // eu la 2 dimineata realizand ca iubesc java
            Thread.sleep(1);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }
}
