import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;

public class UDPServerSocket implements AutoCloseable {
    private DatagramSocket socket;
    private int port;

    public UDPServerSocket(int port) throws SocketException {
        this.port = port;
        socket = new DatagramSocket(port);
    }

    public int getPort() {
        return port;
    }

    public void processRequest() throws IOException {
        byte[] buffer = new byte[256];
        DatagramPacket receivedPacket = new DatagramPacket(buffer, buffer.length);
        socket.receive(receivedPacket);
        String receivedMessage = new String(receivedPacket.getData()).trim();
        String sentMessage;
        if(receivedMessage.equals("W?")) {
            sentMessage = "UDPS";
        } else if (receivedMessage.equals("BYE")) {
            sentMessage = "BYE ACK";
            DatagramPacket sentPacket = new DatagramPacket(sentMessage.getBytes(),
                    sentMessage.getBytes().length, receivedPacket.getAddress(), receivedPacket.getPort());
            socket.send(sentPacket);
            close();
            return;
        } else {
            sentMessage = "ACK";
        }
        DatagramPacket sentPacket = new DatagramPacket(sentMessage.getBytes(),
                sentMessage.getBytes().length, receivedPacket.getAddress(), receivedPacket.getPort());
        socket.send(sentPacket);
    }


    @Override
    public void close() {
        if (socket != null && !socket.isClosed()) {
            socket.close();
        }
    }
}
