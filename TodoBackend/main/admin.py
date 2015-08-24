from django.contrib import admin

from main.models import Item, Category


class ItemAdmin(admin.ModelAdmin):
    list_display = ["name", "category", "owner"]


admin.site.register(Item, ItemAdmin)


class CategoryAdmin(admin.ModelAdmin):
    list_display = ["name"]


admin.site.register(Category, CategoryAdmin)
