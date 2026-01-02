from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

ENGINE = create_engine("sqlite:///app.db")
SessionLocal = sessionmaker(bind=ENGINE)

