from .base_repository import BaseRepository
from ..models.user import User
from sqlalchemy.orm import Session

class UserRepository(BaseRepository):
    def __init__(self, session: Session):
        super().__init__(session, User)