import json 

class Config:
    def __init__(self):
        self.config_path = "config.json"

    def get_postgres_url(self):
        with open(self.config_path, "r") as config:
            config_data = json.load(config)
            url =  config_data.get("postgres_url")
            if url:
                return url
            else:
                raise ValueError("Url do postgres nao encontrada")
