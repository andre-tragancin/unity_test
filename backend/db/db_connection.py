import json
from sqlalchemy import create_engine

class DBConnection:
    def __init__(self):
        self.engine = None

    def connect(self):
        with open('config.json', 'r') as config_file:
            config = json.load(config_file)
            url = config['postgres_url']
            self.engine = create_engine(url)
            return self.engine