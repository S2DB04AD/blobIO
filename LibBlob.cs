/*
    Prog: Load & Store Blobs
    Vers: 1
    Auth: Thijs Haker

    Principle statement:
    1. Everything is a file (stream of bytes).
    2. Handle errors explicitly.
    3. Do not modify shared state.
*/

using MySql.Data.MySqlClient;

public static class LibBlob {
    const string QUERY = "INSERT INTO @table(image) VALUES(@key);";

    // Store to filesystem
    public static void StoreBlob(byte[] blob, string path) {
        try {
            File.WriteAllBytes(path, blob);
        } catch (Exception ex) {
            throw ex;
        }
        return;
    }

    // Store to database, without DB connection
    public static void StoreBlob(byte[] blob, string conStr, string table, string key) {
        MySqlConnection conn;
        try {
            conn = new MySqlConnection(conStr);
            conn.Open();
        } catch (Exception ex){
            throw ex;
        }

        var cmd = new MySqlCommand(QUERY, conn);
        cmd.Parameters.AddWithValue("@table", table);
        cmd.Parameters.AddWithValue("@key", key);
        cmd.ExecuteNonQuery();
    }

    // Store to database, with DB connection
    public static void StoreBlob(byte[] blob, MySqlConnection conn, string table, string key) {
        var cmd = new MySqlCommand(QUERY, conn);
        cmd.Parameters.AddWithValue("@table", table);
        cmd.Parameters.AddWithValue("@key", key);
        cmd.ExecuteNonQuery();
        return;
    }
}