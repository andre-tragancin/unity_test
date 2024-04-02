from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy import(
    Column,
    BigInteger
)
from utils.config import Config
from sqlalchemy.orm import sessionmaker
from sqlalchemy import create_engine

Base = declarative_base()

def get_db():
    config = Config()
    db_url = config.get_postgres_url()

    # Crie uma instância de engine
    engine = create_engine(db_url)

    # Crie uma fábrica de sessões
    session = sessionmaker(autocommit=False, autoflush=False, bind=engine)

    # Retorna uma instância da sessão
    db = session()
    try:
        yield db
    finally:
        db.close()


class BaseTable(Base):
    __abstract__=True

    pk= Column(BigInteger,  primary_key=True, autoincrement=True, index=True)
    
