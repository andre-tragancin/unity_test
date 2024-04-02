from sqlalchemy.orm import Session

class BaseRepository:
    def __init__(self, session: Session, model):
        self.session = session
        self.model = model

    def __enter__(self):
        return self
    
    def __exit__(self, exc_type, exc_value, traceback):
        if exc_type is not None:
            self.session.rollback()
        else:
            self.session.commit()
    
    def create_from_schema(self, schema):
        data = schema.dict()
        obj = self.create(**data)
        return obj

    def create(self, **kwargs):
        obj = self.model(**kwargs)
        self.add(obj)
        return obj
    
    def add(self, obj):
        self.session.add(obj)

    