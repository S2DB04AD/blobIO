/*
    Prog: Load & Store Blobs
    Vers: 0
    Auth: Thijs Haker

    Principle statement:
    1. Everything is a file (stream of bytes).
    2. Handle errors explicitly.
    3. Do not modify shared state.
*/


public static class LibBlob {
    // ErrStr and Err considered shared state
    public static string ErrStr { get; private set; }
    public static uint Err {get; private set;}

    // Store to filesystem
    public static void StoreBlob(byte[] blob, string path) {
        return;
    }

    // Store to database, without DB connection
    public static void StoreBlob(byte[] blob, string conStr, string table, string column) {
        return;
    }

    // Store to database, with DB connection
    public static void StoreBlob(byte[] blob, string table, string column) {
        return;
    }
}