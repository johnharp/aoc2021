#lang racket
(require "move.rkt")
(require "state.rkt")
(require "filters.rkt")



(define initial-state (string->state "...........BACDBCDA"))
(define s initial-state)
;(define s2 (string->state "..............DBCDA"))
(define m (moves-from 13))
(display-state s)


