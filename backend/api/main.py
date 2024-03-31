from fastapi import FastAPI
# from api.routes import hello
from api.routes import hello

app = FastAPI()

app.include_router(hello.router)