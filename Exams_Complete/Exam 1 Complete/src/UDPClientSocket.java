import javax.xml.crypto.Data;
import java.io.IOException;
import java.net.*;

public class UDPClientSocket implements AutoCloseable {
    private DatagramSocket socket;

    public UDPClientSocket() throws SocketException {
        socket = new DatagramSocket();
    }

    public String sendAndReceiveMsg(String message, int port) throws UnknownHostException {
        try{
            InetAddress inetAddress = InetAddress.getByName("localhost");
            DatagramPacket sentPacket = new DatagramPacket(message.getBytes(), message.getBytes().length, inetAddress, port);
            socket.send(sentPacket);
            byte[] buffer = new byte[256];
            DatagramPacket receivedPacket = new DatagramPacket(buffer, buffer.length);
            socket.receive(receivedPacket);
            return new String(receivedPacket.getData()).trim();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void close() {
        if (socket != null && !socket.isClosed()) {
            socket.close();
        }
    }
}
