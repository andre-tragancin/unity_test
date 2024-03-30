from sqlalchemy import Column, Integer, String
from .database import BaseTable

class User(BaseTable):
    __tablename__ = 'users'

    nome = Column(String)
    email = Column(String, unique=True)
    senha = Column(String)