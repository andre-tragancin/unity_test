from db.db_connection import DBConnection
import os

def connectDB():
    db_connection = DBConnection()

    # Connect to the database
    engine = db_connection.connect()

    # Test the connection
    try:
        connection = engine.connect()
        print("Successful connection!")
        connection.close()
    except Exception as e:
        print("Error connecting:", e)

def start_server():
    os.system('uvicorn api.main:app --reload')


if __name__== "__main__":
    # connectDB()
    start_server()