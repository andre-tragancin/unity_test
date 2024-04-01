from fastapi import APIRouter

router = APIRouter()

@router.post("create_user/")
async def create_user():
    # chamar o repositorio de usuario para criar.
    return {"data": True}