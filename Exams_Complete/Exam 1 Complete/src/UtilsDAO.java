import java.sql.*;

public class UtilsDAO {
    private static Connection c;

    public static String selectData() throws SQLException {
        String query = "SELECT * FROM cars";
        Statement s = c.createStatement();
        ResultSet rs = s.executeQuery(query);

        StringBuilder sb = new StringBuilder();
        while(rs.next()) {
            sb.append(rs.getInt(1));
            sb.append(" : ");
            sb.append(rs.getFloat(2));
            sb.append(" : ");
            sb.append(rs.getDouble(3));
            sb.append(" : ");
            sb.append(rs.getString(4));
            sb.append(System.lineSeparator());
        }
        return sb.toString();
    }

    public static void closeConnection() {
        try {
            c.close();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    public static void setConnection() {
        try {
            Class.forName("org.sqlite.JDBC");
            c = DriverManager.getConnection("jdbc:sqlite:test.db");
        } catch (ClassNotFoundException | SQLException e) {
            throw new RuntimeException(e);
        }

    }
}
