from flask_sqlalchemy import SQLAlchemy
from sqlalchemy import Column, Integer, String
from database import db


class User(db.Model):
    id = Column(Integer, primary_key=True)
    email = Column(String(192), unique=True)
    password = Column(String(96), nullable=False)
