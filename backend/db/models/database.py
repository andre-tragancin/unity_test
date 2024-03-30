from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy import(
    Column,
    BigInteger
)

Base = declarative_base()


class BaseTable(Base):
    __abstract__=True

    pk= Column(BigInteger,  primary_key=True, autoincrement=True, index=True)
    
