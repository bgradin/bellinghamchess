IMAGE = bellinghamchess
CONTAINER = bellinghamchess-dev

.DEFAULT_GOAL := start

.PHONY: stop start destroy rebuild create help frontend node_modules

node_modules:
	yarn

frontend: node_modules ## Compile frontend
	mkdir -p src/BellinghamChessClub/wwwroot/css
	npx sass --style=compressed \
		sass/main.scss:src/BellinghamChessClub/wwwroot/css/main.min.css

stop: ## Stop dev server
	docker stop $(CONTAINER) >/dev/null 2>&1 || true

start: create ## Start dev server
	docker inspect $(CONTAINER) >/dev/null 2>&1 || docker run -dit -p 8080:5000 -v $(shell pwd)/data:/data --name $(CONTAINER) $(IMAGE)
	docker start $(CONTAINER) >/dev/null 2>&1 || true

destroy: stop ## Destroy dev environment
	docker rm $(CONTAINER) >/dev/null 2>&1 || true
	docker rmi $(IMAGE) >/dev/null 2>&1 || true

rebuild: destroy start ## Rebuild dev environment

create: frontend ## Build dev image
	docker inspect $(IMAGE) >/dev/null 2>&1 || docker build -t $(IMAGE) .

help: ## List available make commands
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'

node_modules: package.json yarn.lock
	yarn
	touch $@
