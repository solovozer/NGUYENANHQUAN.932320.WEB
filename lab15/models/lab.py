from app import db

class Lab(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(100), nullable=False)
    address = db.Column(db.String(200))

    def __repr__(self):
        return f"<ID {self.id} Lab {self.name} Address {self.address}>"