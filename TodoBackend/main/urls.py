from rest_framework import routers
from main.views import UserViewSet, ItemViewSet, CategoryViewSet

__author__ = 'alek'

router = routers.DefaultRouter(trailing_slash=False)
# router.register(r'users', UserViewSet)
router.register(r'items', ItemViewSet)
router.register(r'categories', CategoryViewSet)

def get_router():
    return router