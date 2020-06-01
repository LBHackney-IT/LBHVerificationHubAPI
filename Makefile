.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose run lbhverificationhubapi dotnet build

.PHONY: serve
serve:
	docker-compose up lbhverificationhubapi

.PHONY: shell
shell:
	docker-compose run lbhverificationhubapi sh

.PHONY: test
test:
	docker-compose build lbhverificationhubapitest && docker-compose up lbhverificationhubapitest
