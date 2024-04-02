from fastapi import (APIRouter, Depends)
from db.models.database import get_db
from sqlalchemy.orm import Session
from api.schemas.user import UserSchema
from db.repositories.user import UserRepository

router = APIRouter(tags=["User"])

@router.post("/create_user", response_model=UserSchema)
async def create_user(user: UserSchema,
                      session: Session = Depends(get_db)):
    with UserRepository(session=session) as repo:
        new_user = repo.create_from_schema(user)
    return new_user
