from fastapi import FastAPI
# from api.routes import hello
from api.routes import (hello, user)

app = FastAPI()

app.include_router(hello.router)
app.include_router(user.router)