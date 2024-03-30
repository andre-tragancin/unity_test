"""users table

Revision ID: bee2655cbcf9
Revises: 87a079d1d1ac
Create Date: 2024-03-29 19:59:47.608925

"""
from typing import Sequence, Union

from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision: str = 'bee2655cbcf9'
down_revision: Union[str, None] = '87a079d1d1ac'
branch_labels: Union[str, Sequence[str], None] = None
depends_on: Union[str, Sequence[str], None] = None


def upgrade() -> None:
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_table('users',
    sa.Column('nome', sa.String(), nullable=True),
    sa.Column('email', sa.String(), nullable=True),
    sa.Column('senha', sa.String(), nullable=True),
    sa.Column('pk', sa.BigInteger(), autoincrement=True, nullable=False),
    sa.PrimaryKeyConstraint('pk'),
    sa.UniqueConstraint('email')
    )
    op.create_index(op.f('ix_users_pk'), 'users', ['pk'], unique=False)
    # ### end Alembic commands ###


def downgrade() -> None:
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_index(op.f('ix_users_pk'), table_name='users')
    op.drop_table('users')
    # ### end Alembic commands ###